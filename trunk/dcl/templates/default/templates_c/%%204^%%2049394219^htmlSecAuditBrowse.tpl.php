<?php /* Smarty version 2.6.2, created on 2011-03-01 14:45:13
         compiled from htmlSecAuditBrowse.tpl */ ?>
<?php require_once(SMARTY_DIR . 'core' . DIRECTORY_SEPARATOR . 'core.load_plugins.php');
smarty_core_load_plugins(array('plugins' => array(array('function', 'dcl_calendar_init', 'htmlSecAuditBrowse.tpl', 2, false),array('function', 'dcl_calendar', 'htmlSecAuditBrowse.tpl', 17, false),)), $this); ?>
<!-- $Id: htmlSecAuditBrowse.tpl 80 2007-03-23 05:12:00Z chavousc $ -->
<?php echo smarty_function_dcl_calendar_init(array(), $this);?>


<form class="styled" name="searchForm" method="post" action="<?php echo $this->_tpl_vars['URL_MAIN_PHP']; ?>
">
	<input type="hidden" name="menuAction" value="boSecAudit.ShowResults">
	<fieldset>
		<legend><?php echo @constant('STR_SEC_SECLOG'); ?>
</legend>
		<div>
			<label for="bytype"><?php echo @constant('STR_SEC_GENERATEREPORTFOR'); ?>
:</label>
			<?php echo $this->_tpl_vars['CMB_USERS']; ?>

		</div>
	</fieldset>
	<fieldset>
		<legend><?php echo @constant('STR_SEC_DATERANGE'); ?>
</legend>
		<div>
			<label for="begindate"><?php echo @constant('STR_SEC_BEGIN'); ?>
:</label>
			<?php echo smarty_function_dcl_calendar(array('name' => 'begindate','value' => ($this->_tpl_vars['VAL_BEGINDATE'])), $this);?>

		</div>
		<div>
			<label for="enddate"><?php echo @constant('STR_SEC_ENDING'); ?>
:</label>
			<?php echo smarty_function_dcl_calendar(array('name' => 'enddate','value' => ($this->_tpl_vars['VAL_ENDDATE'])), $this);?>

		</div>
	</fieldset>
	<fieldset>
		<div class="submit"><input type="submit" value="<?php echo @constant('STR_CMMN_GO'); ?>
"></div>
	</fieldset>
</form>