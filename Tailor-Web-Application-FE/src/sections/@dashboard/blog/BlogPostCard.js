import PropTypes from 'prop-types';
import { FormattedMessage, useIntl } from 'react-intl';
import { NavLink as RouterLink, useNavigate } from 'react-router-dom';
import { useState } from 'react';

// @mui
import { alpha, styled } from '@mui/material/styles';
import { Box, Link, Card, Grid, Avatar, Typography, CardContent } from '@mui/material';
// utils
import { fDate } from '../../../utils/formatTime';
import { fShortenNumber } from '../../../utils/formatNumber';
//
import SvgColor from '../../../components/svg-color';
import Iconify from '../../../components/iconify';
import { AdminControls } from '../../../components';
import {
  BasicModal,
} from '../../../components/modals';
// ----------------------------------------------------------------------

const StyledCardMedia = styled('div')({
  position: 'relative',
  paddingTop: 'calc(100% * 3 / 4)',
});

const StyledTitle = styled(Link)({
  height: 44,
  overflow: 'hidden',
  WebkitLineClamp: 2,
  display: '-webkit-box',
  WebkitBoxOrient: 'vertical',
});

const StyledAvatar = styled(Avatar)(({ theme }) => ({
  zIndex: 9,
  width: 32,
  height: 32,
  position: 'absolute',
  left: theme.spacing(3),
  bottom: theme.spacing(-2),
}));

const StyledInfo = styled('div')(({ theme }) => ({
  display: 'flex',
  flexWrap: 'wrap',
  justifyContent: 'flex-end',
  marginTop: theme.spacing(3),
  color: theme.palette.text.disabled,
}));

const StyledCover = styled('img')({
  top: 0,
  width: '100%',
  height: '100%',
  objectFit: 'cover',
  position: 'absolute',
});

// ----------------------------------------------------------------------

// BlogPostCard.propTypes = {
//   post: PropTypes.object.isRequired,
//   index: PropTypes.number,
// };

export default function BlogPostCard({ post, index, onSelected }) {
  const { image, title, shortDescription, cover,  comment, share, author, publishDate } = post;
  const latestPostLarge = index === 0;
  const latestPost = index === 1 || index === 2;

  const navigate = useNavigate();
  const [open, setOpen] = useState(null);
  const [showModal, setShowModal] = useState(false);
  const [showConfirmation, setShowConfirmation] = useState(false);
  const intl = useIntl();

  const onProductEdit = () => {
    setShowModal(true);
  };

  const handleRemove = () => {
    setShowConfirmation(true);
  };

  const onConfirmDeleteArticle = () => {
    // dispatch(deleteNews(selectedNews.id));
    setShowConfirmation(false);
  };

  return (
    <Grid item xs={12} sm={6} md={3}>
      <Card sx={{ position: 'relative' }}>
        <StyledCardMedia>
          <SvgColor
            color="paper"
            src="/assets/icons/shape-avatar.svg"
            sx={{
              width: 80,
              height: 36,
              zIndex: 9,
              bottom: -15,
              position: 'absolute',
              color: 'background.paper',
            }}
          />
          <StyledAvatar
            alt={author}
            src={author}
          />

          <StyledCover alt={title} src={image} />
        </StyledCardMedia>

        <CardContent sx={{ pt: 4 }}>
          <Typography gutterBottom variant="caption" sx={{ color: 'text.disabled', display: 'block' }}>
            {fDate(publishDate)}
          </Typography>

          <StyledTitle
            color="inherit"
            variant="subtitle2"
            underline="hover" >
            {title}
          </StyledTitle>

          <AdminControls
            controlsList={[
              { name: 'edit', onClick: onProductEdit, iconColor: 'black' },
              { name: 'delete', onClick: handleRemove, iconColor: 'black' },
            ]}
          />
          {showConfirmation && (
            <BasicModal
              isError
              open={showConfirmation}
              onClose={() => setShowConfirmation(false)}
              title={<FormattedMessage id = {"lbl.blog-delete-confirmation"}/>}
              onSubmit={onConfirmDeleteArticle}
              save= {intl.formatMessage({ id: "lbl.button.ok" })}
              close = {intl.formatMessage({id: "lbl.button.cancel"})}
            />
          )}
        </CardContent>
      </Card>
    </Grid>
  );
}
