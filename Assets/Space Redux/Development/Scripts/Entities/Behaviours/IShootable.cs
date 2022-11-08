using System.Collections;

public interface IShootable
{
    void TryShoot();
    IEnumerator Shoot();
}