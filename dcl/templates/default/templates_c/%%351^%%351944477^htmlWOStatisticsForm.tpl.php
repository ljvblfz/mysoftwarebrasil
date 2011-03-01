<?php /* Smarty version 2.6.2, created on 2011-03-01 14:45:40
         compiled from htmlWOStatisticsForm.tpl */ ?>
<?php require_once(SMARTY_DIR . 'core' . DIRECTORY_SEPARATOR . 'core.load_plugins.php');
smarty_core_load_plugins(array('plugins' => array(array('function', 'dcl_calendar_init', 'htmlWOStatisticsForm.tpl', 2, false),array('function', 'dcl_validator_init', 'htmlWOStatisticsForm.tpl', 3, false),array('function', 'dcl_calendar', 'htmlWOStatisticsForm.tpl', 45, false),)), $this); ?>
<!-- $Id: htmlWOStatisticsForm.tpl 12 2006-12-01 01:46:51Z mdean $ -->
<?php echo smarty_function_dcl_calendar_init(array(), $this);?>

<?php echo smarty_function_dcl_validator_init(array(), $this);?>

<script language="JavaScript">
<?php echo '
function submitForm(f)
{
	var aValidators = new Array(
		new ValidatorDate(form.elements["begindate"], "{$smarty.const.STR_WOST_BEGIN}"),
		new ValidatorDate(form.elements["enddate"], "{$smarty.const.STR_WOST_ENDING}")
	);
{literal}
	for (var i in aValidators)
	{
		if (!aValidators[i].isValid())
		{
			alert(aValidators[i].getError());
			if (typeof(aValidators[i]._Element.focus) == "function")
				aValidators[i]._Element.focus();
			return false;
		}
	}

	return true;
}
'; ?>

</script>
<form class="styled" onsubmit="return submitForm(this);" name="searchForm" method="post" action="<?php echo $this->_tpl_vars['URL_MAIN_PHP']; ?>
">
	<input type="hidden" name="menuAction" value="htmlWOStatistics.ShowUserVsProductStatus">
	<fieldset>
		<legend><?php echo @constant('STR_WOST_SSTITLE'); ?>
</legend>
		<div>
			<label for="people"><?php echo @constant('STR_WOST_PERSONNEL'); ?>
:</label>
			<?php echo $this->_tpl_vars['CMB_PEOPLE']; ?>

		</div>
		<div>
			<label for="products"><?php echo @constant('STR_WOST_PRODUCTS'); ?>
:</label>
			<?php echo $this->_tpl_vars['CMB_PRODUCTS']; ?>

		</div>
	</fieldset>
	<fieldset>
		<legend><?php echo @constant('STR_WOST_CLOSEDWO'); ?>
</legend>
		<div>
			<label for="begindate"><?php echo @constant('STR_WOST_BEGIN'); ?>
:</label>
			<?php echo smarty_function_dcl_calendar(array('name' => 'begindate'), $this);?>

		</div>
		<div>
			<label for="enddate"><?php echo @constant('STR_WOST_ENDING'); ?>
:</label>
			<?php echo smarty_function_dcl_calendar(array('name' => 'enddate'), $this);?>

		</div>
	</fieldset>
	<fieldset>
		<div class="submit">
			<input type="submit" value="<?php echo @constant('STR_CMMN_GO'); ?>
">
			<input type="reset" value="<?php echo @constant('STR_CMMN_RESET'); ?>
">
		</div>
	</fieldset>
</form>