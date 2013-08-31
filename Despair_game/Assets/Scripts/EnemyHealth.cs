// Выводит бар, показывающий состояние здоровья игрока

using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	//публичные переменные для настроек
	public int maxHealth = 100;
	
	//блок переменных локального пользования
	public int _curHealth = 100;
	//активация показа состояния здоровья
	private bool showHelthBar = true;
	
	private float healthBarLength;
	//производятся начальные расчеты при создании объекта
	void Start () {
		//задаем начальную ширину бара здоровья
		healthBarLength = Screen.width /2;
		//предотвращаем ввод неправильного значения 
		//максимального здоровья
		if(maxHealth<1) maxHealth=1;
		_curHealth = maxHealth;
		//изначально не показывать состояние здоровья
		HideHealthBar();
	}
	
	
	void Update () {

	}
	// Выводится сам бар посредством графического интерфейса
	//событие вывода этого интерфейса - стандартное
	void OnGUI(){
		if (showHelthBar){
		//выводится бар состояния здоровья и числовые значения его
		GUI.Box(new Rect(10,40,healthBarLength,20),_curHealth + "/" + maxHealth);
		}
	}
	//производим расчет нужной ширины бара состояния здоровья
	//исходя из текущего состояния здоровья
	public void AddjustCurrentHealth( int adj){
		//adj - это изменение состояния здоровья а не его значение
		//_curHealth = adj; - старое значение
		_curHealth += adj; //новое значени
		//блок по предотвращению получения неверного состояния здоровья
		//меньше нуля и больше максимума
		//так как изменяем здоровье из вне
		if(_curHealth < 0) _curHealth =0;
		if(_curHealth > maxHealth) _curHealth = maxHealth;
		//расчет бара непосредственно
		healthBarLength = (Screen.width / 2) * (_curHealth / (float)maxHealth);
	}
	// показать состояние здоровья
	public void ShowHealthBar()
	{
		showHelthBar  = true;
	}
	//скрыть состояние здоровья
	public void HideHealthBar()
	{
		showHelthBar = true;
	}
}
