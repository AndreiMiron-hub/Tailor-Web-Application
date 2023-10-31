import { React, useState} from 'react';
import PropTypes from 'prop-types';
// import { Button } from 'react-native';

// @mui
import { styled } from '@mui/material/styles';
import { Autocomplete, InputAdornment, Popper, TextField, Button } from '@mui/material';
// components
import Iconify from '../../../components/iconify';

// ----------------------------------------------------------------------

const StyledPopper = styled((props) => <Popper placement="bottom-start" {...props} />)({
  width: '280px !important',
});

const StyledSearchbar = styled('div')(({ theme }) => ({
  zIndex: 99,
  width: '100%',
  display: 'flex',
  alignItems: 'center',
  height: 64,
}));

// ----------------------------------------------------------------------

BlogPostsSearch.propTypes = {
  posts: PropTypes.array.isRequired,
};

export default function BlogPostsSearch({ posts }) {
  const [open, setOpen] = useState(false);

  const handleOpen = () => {
    setOpen(!open);
  };

  const handleClose = () => {
    setOpen(false);
  };
  return (
    <StyledSearchbar>
    <Autocomplete
      sx={{ width: 280, color: 'white' }}
      autoHighlight
      popupIcon={null}
      PopperComponent={StyledPopper}
      options={posts}
      getOptionLabel={(post) => post.title}
      isOptionEqualToValue={(option, value) => option.id === value.id}
      renderInput={(params) => (
        <TextField
          {...params}
          placeholder="Search for post..."
          InputProps={{
            ...params.InputProps,
            startAdornment: (
              <InputAdornment position="start">
                <Iconify icon={'eva:search-fill'} sx={{ ml: 1, width: 20, height: 20, color: 'black' }} />
              </InputAdornment>
            ),
          }}
        />
      )}
    />
      <Button variant="contained" onClick={handleClose} 
        sx = {{ 
          ml: '20px',
          backgroundColor: '#454456', 
          color: 'white',
          '&:hover': {
            backgroundColor: '#DEB18A',
            border : '2px solid #454456',
            color: '#454456'
          },
          '&:active': {
            backgroundColor: '#454456',
            color: 'white',
          },
          }}>
        Search
      </Button>
    </StyledSearchbar>
  );
}
