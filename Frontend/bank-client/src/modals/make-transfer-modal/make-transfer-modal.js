import React from 'react'
import { useDispatch } from 'react-redux'
import ModalBase from '../../components/modal/modal-base'
import { close } from '../../redux/reducers/modal-reducer'
import MakeTransferForm from './make-transfer-form'

function MakeTransferModal() {
	const dispatch = useDispatch()

	const primaryAction = {
		text: 'Send',
		action: () => alert('Money sent')
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