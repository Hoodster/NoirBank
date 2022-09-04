import { useSelector } from 'react-redux'

export const getModalData = () => useSelector((state) => state.modal.modalData)