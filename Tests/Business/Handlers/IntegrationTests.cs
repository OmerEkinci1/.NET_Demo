using Business.Constants;
using Business.Handlers.Interpolations.Commands;
using Business.Handlers.Interpolations.Queries;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentAssertions;
using MediatR;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Business.Handlers.Interpolations.Commands.CreateIntegrationCommand;
using static Business.Handlers.Interpolations.Commands.DeleteIntegrationCommand;
using static Business.Handlers.Interpolations.Commands.UpdateIntegrationCommand;
using static Business.Handlers.Interpolations.Queries.GetIntegrationsQuery;
using static Business.Handlers.Languages.Commands.DeleteLanguageCommand;

namespace Tests.Business.Handlers
{
    [TestFixture]
    public class IntegrationTests
    {
        private Mock<IIntegrationRepository> _integrationRepository;
        private Mock<IMediator> _mediator;

        [SetUp]
        public void Setup()
        {
            _integrationRepository = new Mock<IIntegrationRepository>();
            _mediator = new Mock<IMediator>();
        }

        [Test]
        public async Task Integration_CreateCommand_Success()
        {
            Integration rt = null;
            // Arrange
            var command = new CreateIntegrationCommand();
            // propertyler buraya yazılacak
            // command.LanguageName = "deneme";

            _integrationRepository.Setup(x => x.GetAsync(It.IsAny<Expression<Func<Integration, bool>>>()))
                        .ReturnsAsync(rt);

            _integrationRepository.Setup(x => x.Add(It.IsAny<Integration>())).Returns(new Integration());

            var handler = new CreateIntegrationCommandHandler(_integrationRepository.Object, _mediator.Object);
            var x = await handler.Handle(command, new System.Threading.CancellationToken());

            _integrationRepository.Verify(x => x.SaveChangesAsync());
            x.Success.Should().BeTrue();
            x.Message.Should().Be(Messages.Added);
        }

        [Test]
        public async Task Integration_UpdateCommand_Success()
        {
            // Arrange
            var command = new UpdateIntegrationCommand();
            // command.LanguageName = "test";

            _integrationRepository.Setup(x => x.GetAsync(It.IsAny<Expression<Func<Integration, bool>>>()))
                        .ReturnsAsync(new Integration() { /*TODO:propertyler buraya yazılacak LanguageId = 1, LanguageName = "deneme"*/ });

            _integrationRepository.Setup(x => x.Update(It.IsAny<Integration>())).Returns(new Integration());

            var handler = new UpdateIntegrationCommandHandler(_integrationRepository.Object, _mediator.Object);
            var x = await handler.Handle(command, new System.Threading.CancellationToken());

            _integrationRepository.Verify(x => x.SaveChangesAsync());
            x.Success.Should().BeTrue();
            x.Message.Should().Be(Messages.Updated);
        }

        [Test]
        public async Task Integration_DeleteCommand_Success()
        {
            // Arrange
            var command = new DeleteIntegrationCommand();

            _integrationRepository.Setup(x => x.GetAsync(It.IsAny<Expression<Func<Integration, bool>>>()))
                        .ReturnsAsync(new Integration() { /*TODO:propertyler buraya yazılacak LanguageId = 1, LanguageName = "deneme"*/ });

            _integrationRepository.Setup(x => x.Delete(It.IsAny<Integration>()));

            var handler = new DeleteIntegrationCommandHandler(_integrationRepository.Object, _mediator.Object);
            var x = await handler.Handle(command, new System.Threading.CancellationToken());

            _integrationRepository.Verify(x => x.SaveChangesAsync());
            x.Success.Should().BeTrue();
            x.Message.Should().Be(Messages.Deleted);
        }

        [Test]
        public async Task Integration_GetQueries_Success()
        {
            var query = new GetIntegrationsQuery();

            _integrationRepository.Setup(x => x.GetListAsync(It.IsAny<Expression<Func<Integration, bool>>>()))
                .ReturnsAsync(new List<Integration> { new Integration() }.AsQueryable());

            var handler = new GetIntegrationQueryHandler(_integrationRepository.Object, _mediator.Object);

            var x = await handler.Handle(query, new System.Threading.CancellationToken());

            x.Success.Should().BeTrue();
            ((List<Integration>)x.Data).Count.Should().BeGreaterThan(1);
        }

        //[Test]
        //public async Task Integration_GetQuery_Success()
        //{
        //    var query = new GetIntegrationByIdQuery();

        //    _integrationRepository.Setup(x => x.GetAsync(It.IsAny<Expression<Func<Integration, bool>>>()))
        //        .ReturnsAsync(new Integration());

        //    var handler = new GetIntegrationQueryHandler(_integrationRepository.Object, _mediator.Object);

        //    var x = await handler.Handle(query, new System.Threading.CancellationToken());

        //    x.Success.Should().BeTrue();
        //}
    } 
}
