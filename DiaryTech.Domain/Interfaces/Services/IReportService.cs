using DiaryTech.Domain.Dto;
using DiaryTech.Domain.Result;

namespace DiaryTech.Domain.Interfaces.Services;

/// <summary>
/// Сервис отвечающий за роботу с доменной части отчета
/// </summary>
public interface IReportService
{
    /// <summary>
    /// Получение всех отчетов пользователя
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<CollectionResult<ReportDto>> GetReportsAsync(long userId);
}