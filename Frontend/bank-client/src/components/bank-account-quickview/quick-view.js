import React from 'react'
import { useDispatch } from 'react-redux'
import { DEPOSIT_MONEY } from '../../modals/constants'
import { open, setModalData } from '../../redux/reducers/modal-reducer'
import Button from '../inputs/button/button'
import './quick-view.scss'

function BankAccountQuickview(props) {
	const dispatch = useDispatch()


	const openDepositModal = () => {
		dispatch(setModalData({accountNumber: props.accountKey}))
		dispatch(open(DEPOSIT_MONEY))
	}

	return (
		<div className='nb-account-quickview'>
			<div className='details'>
				<span className='type'>{props.type}</span>
				<span className='name'>{props.name}</span>
				<div>
					<span className='number'>{props.accountNumber}</span>
					<div style={{'marginTop': '18px'}}>
						<span className='amount'>{props.fulls}</span>
						<span className='amount-c'>{`.${props.cents}`}</span>
						<span className='currency'>  PLN</span>
					</div>
				</div>
			</div>
			<div>
				<Button style='accent-inverted' type='general' text='Deposit money' onClick={openDepositModal}/>
			</div>
		</div>
	)
}

export default BankAccountQuickview