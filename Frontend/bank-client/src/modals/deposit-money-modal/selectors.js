import { useSelector } from 'react-redux'

export const getAccountNumber = () => useSelector((state) => state.modal.modalData?.accountNumber)
export const getAmount = () => useSelector((state) => state.modal.modalData?.amount)