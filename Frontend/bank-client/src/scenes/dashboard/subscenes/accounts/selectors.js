import { useSelector } from 'react-redux'

export const getAccounts = () => useSelector((state) => state.user.accounts)