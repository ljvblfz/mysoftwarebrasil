<?php

class Axs_View_Helper_Acao{

	public function setView(Zend_View_Interface $view)
	{
		$this -> view = $view;
	}

	public function Acao($campos)
	{
		if(is_array($campos)){
			$botoes = "";
			foreach($campos as $key => $value){
				if (strtolower($value['tipo']) == 'submit'){
					$botoes .= $this->view->formSubmit($value['nome'], $key, array('class' => 'button button-submit')) . "\n";
				}
				else if ($value['tipo'] == 'button'){
					if(isset($value['destino'])){
						$botoes .= $this->view->formButton($value['nome'], $key, array('onclick' => 'location.href=\''.$this->view->baseUrl.'/'.$value['destino'].'\'', 'class' => 'button'))."\n";
					}
					if(isset($value['javascript'])){
						$botoes .= $this->view->formButton($value['nome'], $key, array('onclick' => 'javascript:'.$value['javascript'], 'class' => 'button'))."\n";
					}
				}
			 }
			}else{
				$botoes = null;
			}
			return $botoes;
		}
	}
