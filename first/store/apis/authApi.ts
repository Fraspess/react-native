import {createApi, fetchBaseQuery} from "@reduxjs/toolkit/query/react";
import {BASE_URL} from "@/constants/urls";
import {serialize} from "object-to-formdata";
import {UserLoginFormData} from "@/schemas/userLoginSchema";

export const authApi = createApi({
    reducerPath: "authApi",
    baseQuery: fetchBaseQuery({
        baseUrl: BASE_URL + '/api/Auth',
        prepareHeaders: (headers) => {
            headers.set('ngrok-skip-browser-warning', 'true');
            return headers;
        },
    }),

    endpoints: (builder) => ({
        login: builder.mutation<void, UserLoginFormData>({
            query: (body) => ({
                url: "",
                method:"POST",
                body:body
            })
        })
    })
})


export const {
    useLoginMutation
} = authApi

