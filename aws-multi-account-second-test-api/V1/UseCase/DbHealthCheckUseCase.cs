using Microsoft.Extensions.HealthChecks;
using aws_multi_account_second_test_api.V1.Boundary;

namespace aws_multi_account_second_test_api.UseCase.V1
{
    public class DbHealthCheckUseCase
    {
        private readonly IHealthCheckService _healthCheckService;

        public DbHealthCheckUseCase(IHealthCheckService healthCheckService)
        {
            _healthCheckService = healthCheckService;
        }

        public HealthCheckResponse Execute()
        {
            var result = _healthCheckService.CheckHealthAsync().Result;

            bool success = result.CheckStatus == CheckStatus.Healthy;
            return new HealthCheckResponse(success, result.Description);
        }
    }

}
