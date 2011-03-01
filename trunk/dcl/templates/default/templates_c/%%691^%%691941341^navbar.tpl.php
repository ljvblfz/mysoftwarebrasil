<?php /* Smarty version 2.6.2, created on 2011-03-01 11:17:41
         compiled from navbar.tpl */ ?>
<!-- $Id: navbar.tpl 12 2006-12-01 01:46:51Z mdean $ -->
<ul>
	<li><h3><?php echo $this->_tpl_vars['VAL_TITLE']; ?>
</h3>
		<ul><?php if (isset($this->_sections['navboxitem'])) unset($this->_sections['navboxitem']);
$this->_sections['navboxitem']['name'] = 'navboxitem';
$this->_sections['navboxitem']['loop'] = is_array($_loop=$this->_tpl_vars['VAL_NAVBOXITEMS']) ? count($_loop) : max(0, (int)$_loop); unset($_loop);
$this->_sections['navboxitem']['show'] = true;
$this->_sections['navboxitem']['max'] = $this->_sections['navboxitem']['loop'];
$this->_sections['navboxitem']['step'] = 1;
$this->_sections['navboxitem']['start'] = $this->_sections['navboxitem']['step'] > 0 ? 0 : $this->_sections['navboxitem']['loop']-1;
if ($this->_sections['navboxitem']['show']) {
    $this->_sections['navboxitem']['total'] = $this->_sections['navboxitem']['loop'];
    if ($this->_sections['navboxitem']['total'] == 0)
        $this->_sections['navboxitem']['show'] = false;
} else
    $this->_sections['navboxitem']['total'] = 0;
if ($this->_sections['navboxitem']['show']):

            for ($this->_sections['navboxitem']['index'] = $this->_sections['navboxitem']['start'], $this->_sections['navboxitem']['iteration'] = 1;
                 $this->_sections['navboxitem']['iteration'] <= $this->_sections['navboxitem']['total'];
                 $this->_sections['navboxitem']['index'] += $this->_sections['navboxitem']['step'], $this->_sections['navboxitem']['iteration']++):
$this->_sections['navboxitem']['rownum'] = $this->_sections['navboxitem']['iteration'];
$this->_sections['navboxitem']['index_prev'] = $this->_sections['navboxitem']['index'] - $this->_sections['navboxitem']['step'];
$this->_sections['navboxitem']['index_next'] = $this->_sections['navboxitem']['index'] + $this->_sections['navboxitem']['step'];
$this->_sections['navboxitem']['first']      = ($this->_sections['navboxitem']['iteration'] == 1);
$this->_sections['navboxitem']['last']       = ($this->_sections['navboxitem']['iteration'] == $this->_sections['navboxitem']['total']);
?><li><a href="<?php echo $this->_tpl_vars['VAL_NAVBOXITEMS'][$this->_sections['navboxitem']['index']]['onclick']; ?>
"><?php echo $this->_tpl_vars['VAL_NAVBOXITEMS'][$this->_sections['navboxitem']['index']]['text']; ?>
</a></li><?php endfor; endif; ?></ul>
	</li>
</ul>