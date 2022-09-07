import { useSelector } from 'react-redux'

export const getFirstName = () => useSelector((state) => state.user.profile?.firstName)
export const getLastName = () => useSelector((state) => state.user.profile?.lastName)