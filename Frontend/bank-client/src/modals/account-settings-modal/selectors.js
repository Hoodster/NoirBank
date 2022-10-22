import { useSelector } from 'react-redux'

export const getAccountInfo = () => useSelector((state) => state.user.profile)