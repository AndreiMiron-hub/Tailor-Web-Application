import React from 'react';

import { IconButton as MUIIconButton } from '@mui/material';

import TWAIcon from '../icons';

const IconButton = ({ name, onClick, iconColor }) => {
  return (
    <MUIIconButton sx={{ color: iconColor }} onClick={onClick} size='small'>
      <TWAIcon name = {name}/>
    </MUIIconButton>
  );
};

export default IconButton;
