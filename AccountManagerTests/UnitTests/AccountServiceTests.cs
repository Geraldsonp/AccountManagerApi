using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ApplicationLayer.Domain;
using ApplicationLayer.Domain.Contracts;
using ApplicationLayer.Domain.Enums;
using ApplicationLayer.Domain.Models;
using ApplicationLayer.Services;
using NSubstitute;
using Xunit;

namespace AccountManagerTests.UnitTests
{
    public class AccountServiceTests
    {
        private readonly IAccountRepository _accountRepository;
        private readonly AccountService _accountService;

        public AccountServiceTests()
        {
            _accountRepository = Substitute.For<IAccountRepository>();
            _accountService = new AccountService(_accountRepository);
        }

        [Fact]
        public async Task CreateAccountAsync_ShouldCreateAccountWithCorrectProperties()
        {
            // Arrange
            var initialBalance = 1000m;
            var accountType = AccountType.Checking;
            var clientId = 1;

            var account = new Account
            {
                InitialBalance = initialBalance,
                AccountType = accountType,
                ClientId = clientId,
                Status = Status.Active
            };

            _accountRepository.Create(Arg.Any<Account>()).Returns(callInfo =>
            {
                var createdAccount = callInfo.Arg<Account>();
                return Task.FromResult(createdAccount);
            });

            // Act
            var result = await _accountService.CreateAccountAsync(account);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(initialBalance, result.InitialBalance);
            Assert.Equal(accountType, result.AccountType);
            Assert.Equal(Status.Active, result.Status);
            Assert.Equal(clientId, result.ClientId);
            await _accountRepository.Received(1).Create(Arg.Any<Account>());
        }

        [Fact]
        public async Task GetAccountByClientAsync_ShouldReturnAccountWithTransactions()
        {
            // Arrange
            var accountNumber = "123456";
            var clientId = 1;
            var account = new Account
            {
                AccountNumber = accountNumber,
                ClientId = clientId,
            };

            account.ProccesTransaction(new Transaction(100m, accountNumber));
            account.ProccesTransaction(new Transaction(50m, accountNumber));

            _accountRepository.GetAccountWithTransactions(accountNumber, clientId).Returns(account);

            // Act
            var result = await _accountService.GetAccountByClientAsync(accountNumber, clientId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(accountNumber, result.AccountNumber);
            Assert.Equal(clientId, result.ClientId);
            Assert.Equal(account.Transactions.Count, result.Transactions.Count);
            Assert.Equal(account.Transactions.Sum(t => t.Amount), result.GetCurrentBalance());
            await _accountRepository.Received(1).GetAccountWithTransactions(accountNumber, clientId);
        }

        [Fact]
        public async Task GetAccountsByClientAsync_ShouldReturnAccounts()
        {
            // Arrange
            var clientId = 1;
            var accounts = new List<Account>
            {
                new Account { AccountNumber = "123456", ClientId = clientId },
                new Account { AccountNumber = "789012", ClientId = clientId }
            };

            _accountRepository.GetAccountsWithTransactions(clientId).Returns(accounts);

            // Act
            var result = await _accountService.GetAccountsByClientAsync(clientId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(accounts.Count, result.Count());
            Assert.Equal(accounts.Select(a => a.AccountNumber), result.Select(a => a.AccountNumber));
            await _accountRepository.Received(1).GetAccountsWithTransactions(clientId);
        }

        [Fact]
        public async Task UpdateAccountStatusAsync_ShouldUpdateAccountStatus()
        {
            // Arrange
            var accountNumber = "123456";
            var accountStatus = Status.Inactive;
            var account = new Account { AccountNumber = accountNumber, Status = Status.Active };

            _accountRepository.Get(Arg.Is<Expression<Func<Account, bool>>>(expr => expr.Compile()(account))).Returns(Task.FromResult(account));

            // Act
            var result = await _accountService.UpdateAccountStatusAsync(accountStatus, accountNumber);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(accountNumber, result.AccountNumber);
            Assert.Equal(accountStatus, result.Status);
            await _accountRepository.Received(1).Update(account);
        }

        [Fact]
        public async Task GetAccountAsync_ShouldReturnAccountWithTransactions()
        {
            // Arrange
            var accountId = "123456";
            var account = new Account
            {
                AccountNumber = accountId
            };
            account.ProccesTransaction(new Transaction(100m, accountId));
            account.ProccesTransaction(new Transaction(50m, accountId));

            _accountRepository.GetAccountWithTransactions(accountId).Returns(account);

            // Act
            var result = await _accountService.GetAccountAsync(accountId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(accountId, result.AccountNumber);
            Assert.Equal(account.Transactions.Count, result.Transactions.Count);
            Assert.Equal(account.Transactions.Sum(t => t.Amount), result.GetCurrentBalance());
            await _accountRepository.Received(1).GetAccountWithTransactions(accountId);
        }

        [Fact]
        public async Task GetAccountsAsync_ShouldReturnAccounts()
        {
            // Arrange
            var accounts = new List<Account>
            {
                new Account { AccountNumber = "123456" },
                new Account { AccountNumber = "789012" }
            };

            _accountRepository.GetAccountsWithTransactions().Returns(accounts);

            // Act
            var result = await _accountService.GetAccountsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(accounts.Count, result.Count());
            Assert.Equal(accounts.Select(a => a.AccountNumber), result.Select(a => a.AccountNumber));
            await _accountRepository.Received(1).GetAccountsWithTransactions();
        }
    }
}