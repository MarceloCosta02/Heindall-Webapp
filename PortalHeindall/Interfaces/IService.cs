namespace AppHeindall.Interfaces;

public interface IService<T>
{
	Task<IEnumerable<T>> Obter();

	Task<T> ObterPorId(int id);

	Task Criar(T item);

	Task Atualizar(int id, T item);

	Task Remover(int id);
}
