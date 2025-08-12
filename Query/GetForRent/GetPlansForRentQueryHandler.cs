using MediatR;
using registerAPI.Entity;

namespace registerAPI.Query.GetForRent
{
    public class GetPlansForRentQueryHandler : IRequestHandler<GetPlansForRentQuery, Dictionary<int, string>>
    {
        private readonly ILogger<GetPlansForRentQueryHandler> _logger;
        public GetPlansForRentQueryHandler(ILogger<GetPlansForRentQueryHandler> logger)
        {
            _logger = logger;

        }
        public Task<Dictionary<int, string>> Handle(GetPlansForRentQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Start Get Plans For Rent");

                var listPlans = PeriodPlans();

                _logger.LogInformation("Ended Get Plans For Rent");
                return listPlans;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get Plans For Rent - Error {ex.Message}");
                throw new Exception("Erro ao buscar planos");
            }
        }

        public async Task<Dictionary<int, string>> PeriodPlans()
        {
            var periodLocation = new Dictionary<int, string>()
            {
                {1, "7 dias com custo de R$30,00 por dia" },
                {2, "15 dias com um custo de R$28,00 por dia" },
                {3, "30 dias com um custo de R$22,00 por dia" },
                {4, "45 dias com um custo de R$20,00 por dia" },
                {5, "50 dias com um custo de R$18,00 por dia" }
            };

            return periodLocation;
        }
        

           


        



    }


}
