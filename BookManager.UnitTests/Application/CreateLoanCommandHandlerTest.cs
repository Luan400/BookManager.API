using BookManager.Application.Command.CreateLoans;
using BookManager.Domain.Entities;
using BookManager.Domain.Repositories;
using BookManager.Infrastructure.Persistence;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.UnitTests.Application
{
    public class CreateLoanCommandHandlerTest
    {
        [Fact]

        public async Task TestIfLoansCreateWork()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var donationRepositoryMock = new Mock<ILoanRepository>();

            // Configura o mock para retornar o mock do repositório de doações
            unitOfWorkMock.Setup(uow => uow.LoanRepository).Returns(donationRepositoryMock.Object);

            // Cria uma instância do comando com os parâmetros necessários
            var createDonateCommand = new CreateLoansCommand(5, 4, new DateTime(2024, 04, 03));

            // Cria a instância do handler com o mock do IUnitOfWork
            var createDonationCommandHandler = new CreateLoansCommandHandler(unitOfWorkMock.Object);

            // Act
            var id = await createDonationCommandHandler.Handle(createDonateCommand, new CancellationToken());

            // Assert
            Assert.True(id >= 0);

            // Verifica se o método AddAsync foi chamado exatamente uma vez
            donationRepositoryMock.Verify(pr => pr.AddAsync(It.IsAny<Loans>()), Times.Once);
        }
    }
}
