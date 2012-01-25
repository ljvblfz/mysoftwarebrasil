<?php

interface Axs_Controller_Button_IButtonObservable
{
	public function attachObserver(Axs_Controller_Button_IButtonObserver $dependent);
	public function detachObserver(Axs_Controller_Button_IButtonObserver $dependent);
	public function notify();
}