<?php

class Zend_View_Helper_Label{

	public function setView(Zend_View_Interface $view)
	{
		$this -> view = $view;
	}


	protected function title($mensagem)
	{
		if (empty($mensagem) || is_null($mensagem)){
			return '';
		}else{
			$resposta = " onmouseover=\"Tip('" . $mensagem . "')\" onmouseout=\"UnTip()\" style=\"cursor: help;\"";
			return $resposta;
		}
	}


	public function label($id, $texto = "", $params = null)
	{
		$type = isset($this -> view -> ajuda[$id]['obrigatorio'])?$this -> view -> ajuda[$id]['obrigatorio']:0;

		if (empty($params['color'])){
			$color = "red";
		}else{
			$color = $params['color'];
		}

		$ajuda = (isset($this -> view -> ajuda[$id]['msg']))?$this -> title($this -> view -> ajuda[$id]['msg']):'';
		$retorno = '';
		if ($type == 0){
			$retorno = "
						<strong id=\"lb{$id}\" class=\"label\" {$ajuda}>
							{$texto}
						</strong>
					";
		}
		if ($type == 1){
			$retorno = "
						<strong id=\"lb{$id}\" class=\"label\" {$ajuda}>
							{$texto}
						</strong>
						<FONT color=\"$color\">*</FONT></label>
					";
		}
		if ($type == 2){
			$retorno = "
						<strong id=\"lb{$id}\" class=\"label\" {$ajuda}>
							{$texto}
						</strong>
						<FONT color=\"$color\">{$texto}</FONT></label>
					";
		}

		return ($retorno);
	}
}
