import { createBrowserRouter } from "react-router";
import { homeLoader, HomePage } from "@/pages/home";
import { ErrorPage } from "@/pages/error";
import { MainLayout } from "../layouts/MainLayout.tsx";
import { PlaylistPage, playlistLoader } from "@/pages/playlist";

export const router = createBrowserRouter([
    {
        path: "/",
        element: <MainLayout />,
        errorElement: <ErrorPage />,
        children: [
            {
                index: true,
                element: <HomePage />,
                loader: homeLoader,
                errorElement: <ErrorPage />
            },
            {
                path: "/playlist/:id",
                element: <PlaylistPage />,
                loader: playlistLoader,
                errorElement: <ErrorPage />
            }
        ]
    }
])