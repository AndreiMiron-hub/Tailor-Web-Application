import PropTypes from 'prop-types';
import { NavLink as RouterLink } from 'react-router-dom';
// @mui
import { Box, List, ListItemText } from '@mui/material';
//
import { StyledHeaderItem, StyledHeaderItemIcon } from './styles';

// ----------------------------------------------------------------------

HeadNavSection.propTypes = {
  data: PropTypes.array,
};

export default function HeadNavSection({ data = [], ...other }) {
  return (
    <Box {...other}>
      <List disablePadding sx={{ p: 1 }}>
        {data.map((item) => (
          <NavItem key={item.key} item={item} />
        ))}
      </List>
    </Box>
  );
}

// ----------------------------------------------------------------------

NavItem.propTypes = {
  item: PropTypes.object,
};

function NavItem({ item }) {
  const { title, path, icon, info } = item;

  return (
    <StyledHeaderItem
      component={RouterLink}
      to={path}
      sx={{
        display : 'inline-flex',
        width: '8rem',
        '&.active': {
          color: 'text.primary',
          bgcolor: 'action.selected',
          fontWeight: 'fontWeightBold',
        },
      }}
    >
      <StyledHeaderItemIcon >{icon && icon}</StyledHeaderItemIcon>

      <ListItemText  disableTypography primary={title} /> {info && info} 
      
      </StyledHeaderItem>
  );
}
