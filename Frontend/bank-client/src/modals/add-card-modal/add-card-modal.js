import React from 'react'
import { useDispatch } from 'react-redux'
import ModalBase from '../../components/modal/modal-base'
import { close } from '../../redux/reducers/modal-reducer'
import AddCardForm from './add-card-form'

function AddCardModal() {
	const dispatch = useDispatch()

	const primaryActionButton = {
		action: () => prompt('Card added!'),
		text: 'Add new card',
		icon: 'add_card'
	}
	const secondaryActionButton = {
		action: () => dispatch(close()),
		text: 'Cancel'
	}
	return (
		<ModalBase primaryAction={primaryActionButton} secondaryAction={secondaryActionButton} contentPosition='center' title='Add new card'>
			<AddCardForm />
		</ModalBase>
	)
}

export default AddCardModal