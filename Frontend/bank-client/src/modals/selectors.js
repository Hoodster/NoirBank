import { useSelector } from 'react-redux'

export const getModalType = () => useSelector((state) => state.modal.type)