<?php /* Smarty version 2.6.2, created on 2011-03-01 11:14:33
         compiled from htmlMessageInfo.tpl */ ?>
<?php require_once(SMARTY_DIR . 'core' . DIRECTORY_SEPARATOR . 'core.load_plugins.php');
smarty_core_load_plugins(array('plugins' => array(array('modifier', 'escape', 'htmlMessageInfo.tpl', 27, false),)), $this); ?>
<!-- $Id: htmlMessageInfo.tpl 12 2006-12-01 01:46:51Z mdean $ -->
<?php if ($this->_tpl_vars['MESSAGE']->bIsFirst && count ( $this->_tpl_vars['MESSAGE']->aBacktrace ) > 0): ?>
<script language="JavaScript">
<?php echo '
function toggleBacktrace(sUUID)
{
	var o = document.getElementById("div" + sUUID);
	if (o)
	{
		var oSpan = document.getElementById("spn" + sUUID);
		if (o.style.display != "")
		{
			o.style.display = "";
			oSpan.innerHTML = "&lt;&lt;";
		}
		else
		{
			o.style.display = "none";
			oSpan.innerHTML = "&gt;&gt;";
		}
	}
}
'; ?>

</script>
<?php endif; ?>
<div class="dcl_message_info">
	<span><?php echo ((is_array($_tmp=$this->_tpl_vars['MESSAGE']->sTitle)) ? $this->_run_mod_handler('escape', true, $_tmp) : smarty_modifier_escape($_tmp));  if (count ( $this->_tpl_vars['MESSAGE']->aBacktrace ) > 0): ?>&nbsp;&nbsp;[ <a href="#" onclick="toggleBacktrace('<?php echo $this->_tpl_vars['MESSAGE']->sUUID; ?>
');"><?php echo @constant('STR_CMMN_BACKTRACE'); ?>
&nbsp;<span id="spn<?php echo $this->_tpl_vars['MESSAGE']->sUUID; ?>
">&gt;&gt;</span></a> ]<?php endif; ?>:&nbsp;</span>
	<?php echo ((is_array($_tmp=$this->_tpl_vars['MESSAGE']->sMessage)) ? $this->_run_mod_handler('escape', true, $_tmp) : smarty_modifier_escape($_tmp)); ?>

	<?php if (count ( $this->_tpl_vars['MESSAGE']->aBacktrace ) > 0): ?>
	<div id="div<?php echo $this->_tpl_vars['MESSAGE']->sUUID; ?>
" style="display: none;">
	<?php if (isset($this->_sections['message'])) unset($this->_sections['message']);
$this->_sections['message']['name'] = 'message';
$this->_sections['message']['loop'] = is_array($_loop=$this->_tpl_vars['MESSAGE']->aBacktrace) ? count($_loop) : max(0, (int)$_loop); unset($_loop);
$this->_sections['message']['show'] = true;
$this->_sections['message']['max'] = $this->_sections['message']['loop'];
$this->_sections['message']['step'] = 1;
$this->_sections['message']['start'] = $this->_sections['message']['step'] > 0 ? 0 : $this->_sections['message']['loop']-1;
if ($this->_sections['message']['show']) {
    $this->_sections['message']['total'] = $this->_sections['message']['loop'];
    if ($this->_sections['message']['total'] == 0)
        $this->_sections['message']['show'] = false;
} else
    $this->_sections['message']['total'] = 0;
if ($this->_sections['message']['show']):

            for ($this->_sections['message']['index'] = $this->_sections['message']['start'], $this->_sections['message']['iteration'] = 1;
                 $this->_sections['message']['iteration'] <= $this->_sections['message']['total'];
                 $this->_sections['message']['index'] += $this->_sections['message']['step'], $this->_sections['message']['iteration']++):
$this->_sections['message']['rownum'] = $this->_sections['message']['iteration'];
$this->_sections['message']['index_prev'] = $this->_sections['message']['index'] - $this->_sections['message']['step'];
$this->_sections['message']['index_next'] = $this->_sections['message']['index'] + $this->_sections['message']['step'];
$this->_sections['message']['first']      = ($this->_sections['message']['iteration'] == 1);
$this->_sections['message']['last']       = ($this->_sections['message']['iteration'] == $this->_sections['message']['total']);
?>
	<?php if (! $this->_sections['message']['first']): ?>
	<b><?php echo $this->_tpl_vars['MESSAGE']->aBacktrace[$this->_sections['message']['index']]['file']; ?>
 (<?php echo $this->_tpl_vars['MESSAGE']->aBacktrace[$this->_sections['message']['index']]['line']; ?>
)</b>
	:&nbsp;<?php echo $this->_tpl_vars['MESSAGE']->aBacktrace[$this->_sections['message']['index']]['class'];  echo $this->_tpl_vars['MESSAGE']->aBacktrace[$this->_sections['message']['index']]['type'];  echo $this->_tpl_vars['MESSAGE']->aBacktrace[$this->_sections['message']['index']]['function']; ?>
<br>
	<?php endif; ?>
	<?php endfor; endif; ?>
	</div>
	<?php endif; ?>
</div>