<?php /* Smarty version 2.6.2, created on 2011-03-01 21:30:02
         compiled from menu.tpl */ ?>
<?php require_once(SMARTY_DIR . 'core' . DIRECTORY_SEPARATOR . 'core.load_plugins.php');
smarty_core_load_plugins(array('plugins' => array(array('function', 'dcl_config', 'menu.tpl', 9, false),array('function', 'dcl_select_workspace', 'menu.tpl', 30, false),array('modifier', 'escape', 'menu.tpl', 9, false),)), $this); ?>
<!-- $Id: menu.tpl 174 2010-06-05 12:28:24Z mdean $ -->
<link rel="stylesheet" type="text/css" href="<?php echo $this->_tpl_vars['DIR_JS']; ?>
/superfish/css/superfish.css" media="screen">
<script language="JavaScript" type="text/javascript" src="<?php echo $this->_tpl_vars['DIR_JS']; ?>
/jquery-1.4.2.min.js"></script>
<script language="JavaScript" type="text/javascript" src="<?php echo $this->_tpl_vars['DIR_JS']; ?>
/jquery.bgiframe.min.js"></script>
<script language="JavaScript" type="text/javascript" src="<?php echo $this->_tpl_vars['DIR_JS']; ?>
/hoverIntent.min.js"></script>
<script language="JavaScript" type="text/javascript" src="<?php echo $this->_tpl_vars['DIR_JS']; ?>
/superfish.js"></script>
<script language="JavaScript" type="text/javascript" src="<?php echo $this->_tpl_vars['DIR_JS']; ?>
/supersubs.js"></script>
<div id="header">
	<div id="headerleft"><div id="apptitle"><?php echo smarty_function_dcl_config(array('name' => ((is_array($_tmp='DCL_APP_NAME')) ? $this->_run_mod_handler('escape', true, $_tmp) : smarty_modifier_escape($_tmp))), $this);?>
</div></div>
	<div id="headerright">
		<div id="search">
			<?php if ($this->_tpl_vars['PERM_WORKORDERSEARCH'] || $this->_tpl_vars['PERM_TICKETSEARCH'] || $this->_tpl_vars['PERM_PROJECTSEARCH']): ?>
			<form method="POST" action="main.php">
				<input type="hidden" name="menuAction" value="htmlSearchBox.submitSearch">
				<select name="which">
					<?php if ($this->_tpl_vars['PERM_WORKORDERSEARCH']): ?><option value="openworkorders">Open <?php echo $this->_tpl_vars['TXT_WORKORDERS']; ?>
</option>
					<option value="workorders">All <?php echo $this->_tpl_vars['TXT_WORKORDERS']; ?>
</option><?php endif; ?>
					<?php if ($this->_tpl_vars['PERM_PROJECTSEARCH']): ?><option value="opendcl_projects">Open <?php echo $this->_tpl_vars['TXT_PROJECTS']; ?>
</option>
					<option value="dcl_projects">All <?php echo $this->_tpl_vars['TXT_PROJECTS']; ?>
</option><?php endif; ?>
					<?php if ($this->_tpl_vars['PERM_TICKETSEARCH']): ?><option value="opentickets">Open <?php echo $this->_tpl_vars['TXT_TICKETS']; ?>
</option>
					<option value="tickets">All <?php echo $this->_tpl_vars['TXT_TICKETS']; ?>
</option><?php endif; ?>
					<?php if ($this->_tpl_vars['PERM_WORKORDERSEARCH'] || $this->_tpl_vars['PERM_TICKETSEARCH']): ?><option value="tags">Tags</option><?php endif; ?>
				</select>&nbsp;
				<input type="text" name="search_text" size="20">&nbsp;
				<input type="submit" value="Search">
			</form>
			<?php endif; ?>
		</div>
		<div id="quicknav">
			<a href="<?php echo $this->_tpl_vars['LNK_HOME']; ?>
"><?php echo $this->_tpl_vars['TXT_HOME']; ?>
</a>&nbsp;|&nbsp;<?php if ($this->_tpl_vars['PERM_PREFS']): ?><a href="<?php echo $this->_tpl_vars['LNK_PREFERENCES']; ?>
"><?php echo $this->_tpl_vars['TXT_PREFERENCES']; ?>
</a>&nbsp;|&nbsp;<?php endif;  if ($this->_tpl_vars['PERM_WORKSPACE']):  echo smarty_function_dcl_select_workspace(array('default' => $this->_tpl_vars['VAL_WORKSPACE']), $this);?>
&nbsp;|&nbsp;<?php endif; ?><a href="<?php echo $this->_tpl_vars['LNK_LOGOFF']; ?>
"><?php echo $this->_tpl_vars['TXT_LOGOFF']; ?>
</a>
		</div>
	</div>
</div><div class="sf-menu-container"><ul class="sf-menu"><?php if (count($_from = (array)$this->_tpl_vars['VAL_DCL_MENU'])):foreach ($_from as $this->_tpl_vars['menu'] => $this->_tpl_vars['menuItems']):?><li><a href="javascript:;"><?php echo ((is_array($_tmp=$this->_tpl_vars['menu'])) ? $this->_run_mod_handler('escape', true, $_tmp) : smarty_modifier_escape($_tmp)); ?></a><ul><?php if (isset($this->_foreach['mainMenuItems'])) unset($this->_foreach['mainMenuItems']);$this->_foreach['mainMenuItems']['name'] = 'mainMenuItems';$this->_foreach['mainMenuItems']['total'] = count($_from = (array)$this->_tpl_vars['menuItems']);$this->_foreach['mainMenuItems']['show'] = $this->_foreach['mainMenuItems']['total'] > 0;if ($this->_foreach['mainMenuItems']['show']):$this->_foreach['mainMenuItems']['iteration'] = 0;foreach ($_from as $this->_tpl_vars['label'] => $this->_tpl_vars['menuItem']):$this->_foreach['mainMenuItems']['iteration']++;$this->_foreach['mainMenuItems']['first'] = ($this->_foreach['mainMenuItems']['iteration'] == 1);$this->_foreach['mainMenuItems']['last']  = ($this->_foreach['mainMenuItems']['iteration'] == $this->_foreach['mainMenuItems']['total']); if ($this->_tpl_vars['menuItem'][1]):  if (is_array ( $this->_tpl_vars['menuItem'][0] )): ?><ul><?php if (count($_from = (array)$this->_tpl_vars['menuItem'][0])):foreach ($_from as $this->_tpl_vars['subLabel'] => $this->_tpl_vars['subMenuItem']):?><li><a href="<?php if (substr ( $this->_tpl_vars['subMenuItem'][0] , 0 , 7 ) != 'http://'):  echo $this->_tpl_vars['URL_MAIN_PHP']; ?>?menuAction=<?php endif;  echo ((is_array($_tmp=$this->_tpl_vars['subMenuItem'][0])) ? $this->_run_mod_handler('escape', true, $_tmp) : smarty_modifier_escape($_tmp)); ?>"<?php if (substr ( $this->_tpl_vars['subMenuItem'][0] , 0 , 7 ) == 'http://'): ?> target="_blank"<?php endif; ?>><?php echo $this->_tpl_vars['subLabel']; ?></a></li><?php endforeach; unset($_from); endif; ?></ul><?php else:  if (! $this->_foreach['mainMenuItems']['first']): ?></li><?php endif; ?><li><a href="<?php if (substr ( $this->_tpl_vars['menuItem'][0] , 0 , 7 ) != 'http://'):  echo $this->_tpl_vars['URL_MAIN_PHP']; ?>?menuAction=<?php endif;  echo ((is_array($_tmp=$this->_tpl_vars['menuItem'][0])) ? $this->_run_mod_handler('escape', true, $_tmp) : smarty_modifier_escape($_tmp)); ?>"<?php if (substr ( $this->_tpl_vars['menuItem'][0] , 0 , 7 ) == 'http://'): ?> target="_blank"<?php endif; ?>><?php echo $this->_tpl_vars['label']; ?></a><?php endif;  endif;  endforeach; unset($_from); endif; ?></ul></li><?php endforeach; unset($_from); endif; ?></ul></div>
<div style="clear: both;"></div>
<script type="text/javascript">
//<![CDATA[<?php echo '
$(document).ready(function() {
	$(".sf-menu").supersubs().superfish();
';  if ($this->_tpl_vars['PERM_WORKSPACE']):  echo '$("#workspace_id").change(function() { location.href = "';  echo $this->_tpl_vars['URL_MAIN_PHP'];  echo '?menuAction=htmlWorkspaceForm.changeWorkspace&workspace_id=" + $(this).val(); });';  endif;  echo '
});
'; ?>
//]]>
</script>
<div id="left"><?php echo $this->_tpl_vars['NAV_BOXEN']; ?>
</div>
<div id="content"><div style="width:100%;">