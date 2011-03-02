<?php /* Smarty version 2.6.2, created on 2011-03-01 22:03:31
         compiled from htmlPreferences.tpl */ ?>
<?php require_once(SMARTY_DIR . 'core' . DIRECTORY_SEPARATOR . 'core.load_plugins.php');
smarty_core_load_plugins(array('plugins' => array(array('function', 'dcl_validator_init', 'htmlPreferences.tpl', 2, false),array('function', 'dcl_select_watch_action', 'htmlPreferences.tpl', 38, false),)), $this); ?>
<!-- $Id: htmlPreferences.tpl 32 2007-01-08 03:21:18Z mdean $ -->
<?php echo smarty_function_dcl_validator_init(array(), $this);?>

<script language="JavaScript">
<?php echo '
function validateAndSubmit(f)
{
	f.submit();
}
'; ?>

</script>
<form class="styled" method="post" action="<?php echo $this->_tpl_vars['URL_MAIN_PHP']; ?>
">
	<input type="hidden" name="menuAction" value="htmlPreferences.submitModify">
	<fieldset>
		<legend><?php echo @constant('DCL_MENU_PREFERENCES'); ?>
</legend>
<?php if ($this->_tpl_vars['PERM_MODIFYCONTACT']): ?>
		<div class="required">
			<label for="email"><?php echo @constant('STR_CMMN_CONTACT'); ?>
:</label>
			<input type="button" onclick="location.href='<?php echo $this->_tpl_vars['URL_MAIN_PHP']; ?>
?menuAction=htmlContactDetail.show&contact_id=<?php echo $this->_tpl_vars['VAL_CONTACTID']; ?>
'" value="<?php echo @constant('STR_CMMN_EDIT'); ?>
">
			<span>Edit your contact record.</span>
		</div>
<?php endif; ?>
		<div class="required">
			<label for="DCL_PREF_TEMPLATE_SET"><?php echo @constant('STR_CFG_DEFTEMPLATESET'); ?>
:</label>
			<?php echo $this->_tpl_vars['CMB_DEFAULTTEMPLATESET']; ?>

			<span>This is the template set you wish to use when you are logged in.</span>
		</div>
		<div class="required">
			<label for="DCL_PREF_LANGUAGE"><?php echo @constant('STR_CFG_LANGUAGE'); ?>
:</label>
			<?php echo $this->_tpl_vars['CMB_DEFAULTLANGUAGE']; ?>

			<span>Select your default language to use when you are logged in.</span>
		</div>
		<div class="required">
			<label for="DCL_PREF_NOTIFY_DEFAULT">Copy Me on Notification:</label>
			<input type="checkbox" id="DCL_PREF_NOTIFY_DEFAULT" name="DCL_PREF_NOTIFY_DEFAULT" value="Y"<?php if ($this->_tpl_vars['VAL_NOTIFYDEFAULT'] == 'Y'): ?> checked<?php endif; ?>>
		</div>
		<div class="required">
			<label for="DCL_PREF_CREATED_WATCH_OPTION">Watch Activity for Items I Create:</label>
			<?php echo smarty_function_dcl_select_watch_action(array('name' => 'DCL_PREF_CREATED_WATCH_OPTION','default' => $this->_tpl_vars['VAL_CREATEDWATCHOPTION']), $this);?>

		</div>
	</fieldset>
	<fieldset>
		<div class="submit">
			<input type="button" onclick="validateAndSubmit(this.form);" value="<?php echo @constant('STR_CMMN_SAVE'); ?>
">
			<input type="reset" value="<?php echo @constant('STR_CMMN_RESET'); ?>
">
		</div>
	</fieldset>
</form>