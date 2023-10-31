import React, { useState, useMemo } from 'react';
import { useIntl } from 'react-intl';
import { useForm } from 'react-hook-form';
import { yupResolver } from '@hookform/resolvers/yup';
import * as Yup from 'yup';

import { Box, TextField } from '@mui/material';

import BasicModal from './BasicModal';
import { UploadImage } from '../uploadImage';
import { NewsStatus } from '../newsStatus';

const NewsModal = ({ open, onClose, content = null, addNewNews }) => {
  const intl = useIntl();
  const [isImageSelected, setIsImageSelected] = useState(content ? true : null);

  const generateHashTags = (hashtags) => {
    if (!hashtags || hashtags.length === 0) return [];

    return hashtags?.map((hashtag) => {
      return { id: hashtag, text: hashtag };
    });
  };

  const hashtags = useMemo(() => generateHashTags(content?.hashtags), [content?.hashtags]);

  const defaultInputValues = {
    id: content ? content.id : '',
    title: content ? content.title : '',
    description: content ? content.description : '',
    text: content ? content.text : '',
    content: content ? content.content : [],
    hashtags: content ? hashtags : [],
    newsStatus: 2,
  };

  const [values, setValues] = useState(defaultInputValues);

  const validationSchema = Yup.object().shape({
    title: Yup.string().required(
      `${intl.formatMessage({ id: 'lbl.title-required' })} ${intl.formatMessage({
        id: 'lbl.is-required',
      })}`,
    ),
    description: Yup.string().required(
      `${intl.formatMessage({ id: 'lbl.staff-description-required' })} ${intl.formatMessage({
        id: 'lbl.is-height-required',
      })}`,
    ),
    text: Yup.string().required(
      `${intl.formatMessage({ id: 'lbl.text-required' })} ${intl.formatMessage({
        id: 'lbl.is-required',
      })}`,
    ),
  });

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm({
    mode: 'onTouched',
    reValidateMode: 'onTouched',
    defaultValues: defaultInputValues,
    resolver: yupResolver(validationSchema),
  });

  const addNews = () => {
    addNewNews(values);
  };

  const handleChange = (value) => {
    setValues(value);
  };

  const addArticle = () => {
    if (!isImageSelected) {
      setIsImageSelected(false);
      return;
    }
    
    setIsImageSelected(null);
  };

  const getContent = () => (
    <Box
  sx={{
    display: 'flex',
    alignItems: ['center', 'initial', 'initial'],
    flexDirection: 'column',
    '.MuiFormControl-root': {
      mb: '20px',
      color: 'white',
    },
  }}
>
<TextField
  placeholder={intl.formatMessage({ id: 'lbl.title' })}
  name="title"
  label={intl.formatMessage({ id: 'lbl.title' })}
  required
  {...register('title')}
  error={!!errors.title}
  helperText={errors.title?.message}
  value={values.title}
  onChange={(event) => handleChange({ ...values, title: event.target.value })}
  InputProps={{
    style: { color: 'white' },
  }}
/>

  <TextField
    placeholder={intl.formatMessage({ id: 'lbl.staff-description' })}
    name="description"
    label={intl.formatMessage({ id: 'lbl.staff-description' })}
    required
    {...register('description')}
    error={!!errors.description}
    helperText={errors.description?.message}
    value={values.description}
    onChange={(event) => handleChange({ ...values, description: event.target.value })}
    InputProps={{
      style: { color: 'white' },
    }}
  />

  <TextField
    placeholder={intl.formatMessage({ id: 'lbl.text' })}
    name="text"
    label={intl.formatMessage({ id: 'lbl.text' })}
    required
    inputProps={{ maxLength: 1000 }}
    minRows={3}
    maxRows={3}
    multiline
    {...register('text')}
    error={!!errors.text}
    helperText={errors.text?.message}
    value={values.text}
    onChange={(event) => handleChange({ ...values, text: event.target.value })}
    InputProps={{
      style: { color: 'white' },
    }}
  />

  <UploadImage
    name="content"
    values={values}
    setValues={setValues}
    isSelected={isImageSelected}
    setIsSelected={setIsImageSelected}
    errors={errors}
  />

  <NewsStatus values={values} setValues={setValues} />
</Box>
  );

  return (
    <BasicModal
      open={open}
      onClose={onClose}
      title={intl.formatMessage({ id: 'lbl.add-news' })}
      content={getContent()}
      onSubmit={handleSubmit(addArticle)}
      save={content ? 'btn.save' : 'btn.add'}
      width='50rem'
      typographyProps={{ textAlign: 'center' }}
    />
  );
};

export default NewsModal;
