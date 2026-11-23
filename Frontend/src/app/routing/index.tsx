import { createBrowserRouter } from "react-router";
import { App } from "..";
import { homeLoader } from "@/pages/home";

export const router = createBrowserRouter([
    {
        path: "/",
        element: <App />,
        loader: homeLoader
    }
])