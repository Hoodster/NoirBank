import { useSelector } from 'react-redux'

export const getModalData = () => useSelector((state) => state.modal.modalData)
export const getAccounts = () => useSelector((state) => state.user.accounts)