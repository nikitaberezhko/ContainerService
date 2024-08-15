namespace Domain;

/// <summary>
/// Доменная сущность контейнера
/// </summary>
public class Container
{
	public Guid Id { get; set; }
	
	public Guid OrderId { get; set; }
	
	/// <summary>
	/// Номер ISO
	/// </summary>
	public string IsoNumber { get; set; }

	/// <summary>
	/// Идентификатор типа контейнера
	/// </summary>
	public int TypeId { get; set; }
	
	/// <summary>
	/// Свойство для доступа к типу контейнера (для EFCore)
	/// </summary>
	public virtual Type Type { get; set; }

	/// <summary>
	/// Статус занятости контейнера
	/// </summary>
	public bool IsEngaged { get; set; }
	
	/// <summary>
	/// До какого числа занят контейнер
	/// </summary>
	public DateTime? EngagedUntil { get; set; }
	
	/// <summary>
	/// Флаг удаления
	/// </summary>
	public bool IsDeleted { get; set; }
}