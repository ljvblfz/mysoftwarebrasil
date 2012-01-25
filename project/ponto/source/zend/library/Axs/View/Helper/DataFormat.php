<?php

class Zend_View_Helper_DataFormat{

    public function setView(Zend_View_Interface $view)
    {
         $this->view = $view;
    }


	public function DataFormat($value,$format="dd/MM/yyyy")
    {
		if(!empty($value) && $value != null && $value != ""){
			$date = new Zend_Date($value, false);
			return $date->toString($format);
		}
	}
}
