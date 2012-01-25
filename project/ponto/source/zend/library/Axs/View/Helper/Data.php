<?php

class Zend_View_Helper_Data{


	public function setView(Zend_View_Interface $view)
	{
		$this->view = $view;
	}


	public function Data($nome_do_campo,$valor)
	{
		$content = "";
		if(isset($nome_do_campo)){
			$content = $this->view->formText(
												$nome_do_campo, 
												$valor, 
												array(
														'class'=>'dataTxtArea', 
														'maxlength'=>'10',
														"onkeyup"=>"javascript:formataData(this)"
													)
											);
			$content .= "<script type=\"text/javascript\">\n";
			$content .= '$(function() {
							$.datepicker.regional["pt-BR"];
							$( "#'.$nome_do_campo.'" ).datepicker({
								showOn: "button",
								buttonImage: "'.$this->view->baseUrl.'/zend/public/images/calendar.png",
								buttonImageOnly: true
							});
						});';
			$content .= "\n</script>\n";
		}
		return $content;
	}
}
