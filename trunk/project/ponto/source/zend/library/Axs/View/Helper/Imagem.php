<?php
class Zend_View_Helper_Imagem
{
	/**
	 * Método para setar a view dentro do helper.
	 * 
	 * @name setView
	 * @param object Zend_View_Interface
	 * @access public
	 * @return void
	 */
	public function setView(Zend_View_Interface $view)
	{
		$this->view = $view;
	}
	
	/**
	 * Método principal do Helper das imagem de avatar.
	 * 
	 * @name Avatar
	 * @param array $foto
	 * @access public
	 * @return string
	 */
	public function Imagem(array $foto=array())
	{
		$imagem  = @file_get_contents($foto['pathFoto'].$foto['nameFoto']);
		$content = "<img src=\"data:image/gif;base64,".base64_encode($imagem)."\" style = \" width: 170px;\"  />";
		return $content;
	}
}