using System;
using NUnit.Framework;
using SharpTestsEx;
using Trub.Tracker;

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
            var commitMessage = string.Format("Ajustes no teste para validação de Conta a Receber [{0} #{1}]", command, cardId);
            var cardAction = commitMessageInterpretor.Interpret(commitMessage);
            cardAction.Kind.Should().Be.EqualTo(CardActionKind.Close);
        }

        [TestCase("Close"), TestCase("Closed"), TestCase("Fixed")]
        public void IfThereIsCloseCommandWrappedByBracketWithIdCardIdShouldBeFilled(string command)
        {
            var commitMessage = string.Format("Ajustes no teste para validação de Conta a Receber [{0} #{1}]", command, cardId);
            var cardAction = commitMessageInterpretor.Interpret(commitMessage);
            cardAction.CardId.Should().Be.EqualTo(cardId);
        }

        [Test]
        public void IfCommitMessageIsEmptyShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => commitMessageInterpretor.Interpret(""), "Required commit message");
        }
    }
}
