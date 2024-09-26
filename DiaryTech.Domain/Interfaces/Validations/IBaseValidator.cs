using DiaryTech.Domain.Result;

namespace DiaryTech.Domain.Interfaces.Validations;

public interface IBaseValidator<in T> where T : class
{
    BaseResult ValidateOnNull(T model);
}