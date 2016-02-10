//This is a generic interface where T is a placeholder
//for a data type that will be provided by the 
//implementing class.
public interface IDamageable<T>
{
	void Damage(T damageTaken);
}