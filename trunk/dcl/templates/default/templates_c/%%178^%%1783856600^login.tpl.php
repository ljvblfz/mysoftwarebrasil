<?php /* Smarty version 2.6.2, created on 2011-03-01 11:04:04
         compiled from login.tpl */ ?>
<?php require_once(SMARTY_DIR . 'core' . DIRECTORY_SEPARATOR . 'core.load_plugins.php');
smarty_core_load_plugins(array('plugins' => array(array('modifier', 'escape', 'login.tpl', 20, false),)), $this); ?>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN"
        "http://www.w3.org/TR/REC-html40/loose.dtd">
<html>
<head>
<!-- $Id: login.tpl 177 2010-06-05 21:54:26Z mdean $ -->
<meta http-equiv="Set-Cookie" content="DCLINFO=;expires=Sunday, 31-Dec-2000 23:59:59 GMT">
<meta http-equiv="Expires" content="-1">
<title><?php echo $this->_tpl_vars['TXT_TITLE']; ?>
</title>
<script language="JavaScript"><?php echo '
function init()
{
    document.forms[0].elements[\'UID\'].focus();
}
'; ?>
</script>
<link rel="stylesheet" href="<?php echo $this->_tpl_vars['DIR_CSS']; ?>
default.css" type="text/css"></link>
</head>
<body onload="init();">
<h3><?php echo $this->_tpl_vars['VAL_WELCOME']; ?>
</h3>
<form class="styled login" method="post" action="login.php">
<?php if ($this->_tpl_vars['VAL_REFERTO']): ?><input type="hidden" name="refer_to" value="<?php echo ((is_array($_tmp=$this->_tpl_vars['VAL_REFERTO'])) ? $this->_run_mod_handler('escape', true, $_tmp, 'rawurl') : smarty_modifier_escape($_tmp, 'rawurl')); ?>
"><?php endif; ?>
	<fieldset>
		<legend><?php echo $this->_tpl_vars['TXT_LOGIN']; ?>
</legend>
<?php if ($this->_tpl_vars['VAL_ERROR']): ?>
		<div class="help"><?php echo $this->_tpl_vars['VAL_ERROR']; ?>
</div>
<?php endif; ?>
		<div class="required">
			<label for="UID"><?php echo $this->_tpl_vars['TXT_USER']; ?>
:</label>
			<input type="text" maxlength="25" size="25" id="UID" name="UID">
		</div>
		<div class="required">
			<label for="PWD"><?php echo $this->_tpl_vars['TXT_PASSWORD']; ?>
:</label>
			<input type="password" size="25" id="PWD" name="PWD">
		</div>
		<div class="required">
			<label for="domain"><?php echo $this->_tpl_vars['TXT_DOMAIN']; ?>
:</label>
			<?php echo $this->_tpl_vars['CMB_DOMAIN']; ?>

		</div>
	</fieldset>
	<fieldset>
		<div class="submit">
			<input type="submit" value="<?php echo $this->_tpl_vars['BTN_LOGIN']; ?>
">
			<input type="reset" value="<?php echo $this->_tpl_vars['BTN_CLEAR']; ?>
">
		</div>
	</fieldset>
</form>
<div id="poweredby">Powered By <a target="_blank" href="http://www.gnuenterprise.org/">GNU Enterprise</a> <a target="_blank" href="http://dcl.sourceforge.net/">DCL</a> <?php echo $this->_tpl_vars['TXT_VERSION']; ?>
 Copyright (C) 1999-2005 <a target="_blank" href="http://www.fsf.org/">Free Software Foundation</a></div>
</body></html>