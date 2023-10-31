import React from 'react';

import { Button as MuiButton } from '@material-ui/core';

export default function Button(props) {
  const { text, size, color, variant, onClick, ...other } = props;

  return (
    <MuiButton
      {...other}
      variant={variant || 'contained'}
      size={size || 'large'}
      onClick={onClick}
      sx = {{
        color:'#454456',
        backgroundColor:'#DEB18A',
      }}
    >
      {text}
    </MuiButton>
  );
}
