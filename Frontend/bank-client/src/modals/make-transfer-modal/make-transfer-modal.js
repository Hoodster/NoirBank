import React from 'react'
import { useDispatch } from 'react-redux'
import ModalBase from '../../components/modal/modal-base'
import { post } from '../../helpers/api'
import { transferAPI } from '../../helpers/endpoints'
import { close } from '../../redux/reducers/modal-reducer'
import MakeTransferForm from './make-transfer-form'
import { getModalData } from './selectors'

function MakeTransferModal() {
	const dispatch = useDispatch()

	const modalData = getModalData()

	const makeTransfer = () => {
		post(transferAPI, modalData).then(() => {
			dispatch(close())
		})
	}

	const primaryAction = {
		text: 'Send',
		action: () => makeTransfer()
	}

	const secondaryAction = {
		text: 'Cancel',
		action: () => dispatch(close())
	}
	return(
		<ModalBase title='Make a transfer' contentPosition='center' primaryAction={primaryAction} secondaryAction={secondaryAction}>
			<MakeTransferForm />
		</ModalBase>
	)
}

export default MakeTransferModal