<?php
class Zend_View_Helper_Aba
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
	 * Método principal do Helper das abas.
	 * 
	 * @name Aba
	 * @param array $abas
	 * <code>
	 * array(
	 *       array(
	 *             title         => nome_do_botao //string
	 *             action        => action //string
	 *             controller    => controller //string
	 *             params        => array(
	 *                                    chave => valor //array associativo
	 *                                   )
	 *            )
	 *      )
	 * </code>
	 * @access public
	 * @return string
	 */
	public function Aba(array $abas)
	{
		// Inicializa as abas
		$content = "<script src=\"{$this->view->baseUrl}/zend/public/scripts/jquery.ui.tabs.js\"></script>";
		$content .= "<script>
								$(function() {
									$( \"#tabs\" ).tabs();
								});
							</script>";
		
		// Inicializa o corpo das abas
		$content .= "<div class=\"demo\">";
		$content .= "<div id=\"tabs\">";
		$content .= "<ul>";
		// Constrói os botões
		foreach($abas as $key => $value){
			// A classe do primeiro botão é diferente dos demais, para apresentar um efeito de seleção
			$content .= "<li><a href=\"#tabs-{$key}\">{$value['title']}</a></li>";
		}
		$content .= "</ul>";
		
		foreach($abas as $key => $value){

			$content .= "<div id=\"tabs-{$key}\" class=\"fieldLinha\">";
			$content .= "{$this->view->action($value['action'], $value['controller'], $value['module'], $value['params'])}";
			$content .= "</div>";
		}
		$content .= "</div>";
		$content .= "</div><!-- End demo -->";
		return $content;
	}
}