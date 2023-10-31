import { createAsyncThunk, createSlice} from "@reduxjs/toolkit";
import { TwaAPI } from "../../../rest/RestClient";

export const getProducts = createAsyncThunk(
    'products/getProducts',
    async (args, { rejectWithValue }) => {
        try {
            return await TwaAPI.GET('/Product');
        } catch (err) {
            return rejectWithValue(err);
        }
    },
);

export const newProduct = createAsyncThunk(
    'products/newProduct',
    async (productRequest, { rejectWithValue }) => {
      try {
        return await TwaAPI.POST(`/product/`, productRequest);
      } catch (err) {
        return rejectWithValue(err);
      }
    },
  );

export const deleteProduct = createAsyncThunk(
        'products/deleteProduct',
        async (id, { rejectWithValue }) => {
            try {
            return await TwaAPI.DELETE(`/product/${id}`);
            } catch (err) {
            return rejectWithValue(err);
            }
        },
    );

export const updateProduct = createAsyncThunk(
        'products/updateProduct',
        async (productRequest, { rejectWithValue }) => {
            try {
            return await TwaAPI.PUT(`/product/${productRequest.id}`, productRequest);
            } catch (err) {
            return rejectWithValue(err);
            }
        },
    );

const productSlice = createSlice({
    name: 'products',
    initialState: {
        loading: false,
        productError: null,

        products: null,

        selectedProduct: null,

        product_status: null,
        new_product_status: null,
        delete_product_status: null,
        update_product_status: null,
    },

    reducers: {
        setProductError: (state, action) => {
            state.productError = action.payload;
        },
        setProductStatus: (state, action) =>{
            state.product_status = action.payload;
        },
        setSelectedProduct: (state, action) => {
            state.selectedProduct = action.payload;
        },
        setNewProductStatus: (state, action) => {
            state.new_products_status = action.payload;
        },
        setDeleteProductStatus: (state, action) => {
        state.delete_product_status = action.payload;
        },
        setUpdateProductStatus: (state, action) => {
        state.update_product_status = action.payload;
        },
    },

    extraReducers: {
        [getProducts.pending]: (state) => {
            state.product_status = 'loading';
            state.loading = true;
            state.productError = null;
        },
        [getProducts.fulfilled]: (state, action) => {
            state.loading = false;
            state.product_status = 'succes';
            state.products = action.payload;
        },
        [getProducts.rejected]: (state, action) => {
            state.loading = false;
            state.productError = action.payload;
            state.product_status = 'failed';
        },
        [newProduct.pending]: (state) => {
            state.loading = true;
            state.productError = null;
            state.new_products_status = 'loading';
          },
          [newProduct.fulfilled]: (state) => {
            state.loading = false;
            state.new_products_status = 'success';
          },
          [newProduct.rejected]: (state, action) => {
            state.loading = false;
            state.productError = action.payload;
            state.new_products_status = 'failed';
          },

          [deleteProduct.pending]: (state) => {
            state.loading = true;
            state.productError = null;
            state.delete_product_status = 'loading';
          },
          [deleteProduct.fulfilled]: (state) => {
            state.loading = false;
            state.delete_product_status = 'success';
          },
          [deleteProduct.rejected]: (state, action) => {
            state.loading = false;
            state.productError = action.payload;
            state.delete_product_status = 'failed';
          },
      
          [updateProduct.pending]: (state) => {
            state.loading = true;
            state.productError = null;
            state.update_product_status = 'loading';
          },
          [updateProduct.fulfilled]: (state) => {
            state.loading = false;
            state.update_product_status = 'success';
          },
          [updateProduct.rejected]: (state, action) => {
            state.loading = false;
            state.productError = action.payload;
            state.update_product_status = 'failed';
          },
    },
});

export const{
    setNewProductStatus,
    setProductError,
    setProductStatus,
    setSelectedProduct,
    setDeleteProductStatus,
    setUpdateProductStatus,
} = productSlice.actions;

export default productSlice.reducer;