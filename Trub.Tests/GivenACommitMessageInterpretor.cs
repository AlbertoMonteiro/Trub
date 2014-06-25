using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SharpTestsEx;
using TreHub.Models;

namespace Trub.Tests
{
    [TestFixture]
    public class GivenACommitMessageInterpretorWhenInterpretCommitMessage
    {
        const string cardId = "123456";
        private ICommitMessageInterpretor commitMessageInterpretor;
        [SetUp]
        public void SetUp()
        {
            commitMessageInterpretor = new CommitMessageInterpretor();
        }

        [Test]
        public void IfJustIdIsWrappedByBracketCardActionKindShouldBeLog()
        {
            var commitMessage = string.Format("Ajustes no teste para validação de Conta a Receber [#{0}]", cardId);
            var cardAction = commitMessageInterpretor.Interpret(commitMessage);
            cardAction.Kind.Should().Be.EqualTo(CardActionKind.Log);
        }

        [Test]
        public void IfCommitMessageContainsIdWrappedByBracketWithSuffixCardIdShouldBeFilled()
        {
            var commitMessage = string.Format("Ajustes no teste para validação de Conta a Receber [#{0}]", cardId);
            var cardAction = commitMessageInterpretor.Interpret(commitMessage);
            cardAction.CardId.Should().Be.EqualTo(cardId);
        }

        [TestCase("Close"), TestCase("Closed"), TestCase("Fixed")]
        public void IfThereIsCloseCommandWrappedByBracketWithIdCardActionKindShouldBeClose(string command)
        {
            var cardAction = commitMessageInterpretor.Interpret(string.Format("Ajustes no teste para validação de Conta a Receber [{0} #123456]", command));
            cardAction.Kind.Should().Be.EqualTo(CardActionKind.Close);
        }

        [Test]
        public void IfThereIsCloseCommandWrappedByBracketWithIdCardIdShouldBeFilled()
        {
            var cardAction = commitMessageInterpretor.Interpret("Ajustes no teste para validação de Conta a Receber [Close #123456]");
            cardAction.CardId.Should().Be.EqualTo("123456");
        }
    }
}
