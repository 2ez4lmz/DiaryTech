using DiaryTech.Domain.Entity;
using DiaryTech.Domain.Result;

namespace DiaryTech.Domain.Interfaces.Validations;

public interface IReportValidator : IBaseValidator<Report>
{
    /// <summary>
    /// Проверяется наличие отчета, если отчет с переданным названием есть в БД, то создать точно такой же нельзя
    /// Проверяется пользователь, если с UserId пользовател не найден, то такого пользователя нет
    /// </summary>
    /// <param name="report"></param>
    /// <param name="user"></param>
    /// <returns></returns>
    BaseResult CreateValidator(Report report, User user);
}