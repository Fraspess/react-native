// Need to use the React-specific entry point to import createApi
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'
import {ICategoryResponse} from "@/types/ICategoryResponse";
import {BASE_URL} from "@/constants/urls";

// Define a service using a base URL and expected endpoints
export const categoryApi = createApi({
    reducerPath: 'categoryApi',
    baseQuery: fetchBaseQuery({ baseUrl: BASE_URL }),
    endpoints: (builder) => ({
        getCategories: builder.query<ICategoryResponse, void>({
            query: () => `/`,
        }),
    }),
})

// Export hooks for usage in functional components, which are
// auto-generated based on the defined endpoints

export const { useGetCategoriesQuery } = categoryApi