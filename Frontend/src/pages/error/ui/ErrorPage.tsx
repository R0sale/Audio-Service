import { isRouteErrorResponse, Link, useRouteError } from 'react-router'

function getErrorInfo(error: unknown): { title: string; message: string } {
  if (isRouteErrorResponse(error)) {
    if (error.status === 404) {
      return { title: 'Page not found', message: "We couldn't find what you were looking for." }
    }
    return { title: `${error.status} ${error.statusText}`, message: String(error.data ?? 'Something went wrong.') }
  }

  if (error instanceof Error) {
    return { title: 'Something went wrong', message: error.message }
  }

  return { title: 'Something went wrong', message: 'An unexpected error occurred.' }
}

export const ErrorPage = () => {
  const error = useRouteError()
  const { title, message } = getErrorInfo(error)

  return (
    <div className="flex h-full min-h-dvh flex-col items-center justify-center gap-4 bg-surface p-6 text-center">
      <h1 className="text-3xl font-bold text-white">{title}</h1>
      <p className="max-w-md text-muted">{message}</p>
      <Link
        to="/"
        className="rounded-full bg-accent px-6 py-2 font-semibold text-white transition hover:bg-accent-hover"
      >
        Go home
      </Link>
    </div>
  )
}
