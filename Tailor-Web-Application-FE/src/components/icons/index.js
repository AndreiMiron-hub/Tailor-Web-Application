/* eslint-disable consistent-return */
import React from 'react';

import { useTheme } from '@mui/material/styles';
import SportsVolleyballIcon from '@mui/icons-material/SportsVolleyball';
import AddIcon from '@mui/icons-material/Add';
import ModeEditIcon from '@mui/icons-material/ModeEdit';
import DeleteOutlineIcon from '@mui/icons-material/DeleteOutline';

const TWAIcon = ({ name, ...props }) => {
  const theme = useTheme();
  const currentColor = theme.palette.mode === 'light' ? 'black' : 'white';
  switch (name) {
    case 'volleyball':
      return <SportsVolleyballIcon sx={{ size: '10px', color: 'white' }} />;

    case 'add':
      return <AddIcon />;

    case 'edit':
      return <ModeEditIcon />;

    case 'delete':
      return <DeleteOutlineIcon />;

    default:
  }
};

export default TWAIcon;
