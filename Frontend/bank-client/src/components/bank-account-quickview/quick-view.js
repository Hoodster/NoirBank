import React from 'react'
import { useDispatch } from 'react-redux'
import { DEPOSIT_MONEY } from '../../modals/constants'
import { open } from '../../redux/reducers/modal-reducer'
import Button from '../inputs/button/button'
import './quick-view.scss'

function BankAccountQuickview(props) {
	const dispatch = useDispatch()


	const openDepositModal = () => {
		dispatch(open({
			type: DEPOSIT_MONEY,
			data: {
				accountNumber: props.accountKey
			}
		}))
	}

	return (
		<div className='nb-account-quickview'>
			<div className='details'>
				<span className='type'>{props.type}</span>
				<span className='name'>{props.name}</span>
				<div>
					<span className='number'>{props.accountNumber}</span>
					<div style={{ 'marginTop': '18px' }}>
						<span className='amount'>{props.fulls}</span>
						<span className='amount-c'>{`.${props.cents}`}</span>
						<span className='currency'>  PLN</span>
					</div>
				</div>
			</div>
			<div>
				{
					!props.isLocked ? <Button buttonStyle='accent-inverted' type='general' text='Deposit money' onClick={openDepositModal} /> : <h5>Account has been locked</h5>
				}
			</div>
		</div>
	)
}

export default BankAccountQuickview