import React from 'react'
import './quick-view.scss'

function BankAccountQuickview(props) {
	return (
		<div className='nb-account-quickview'>
			<div className='details'>
				<span className='type'>{props.type}</span>
				<span className='name'>{props.name}</span>
				<div>
					<span className='number'>{props.accountNumber}</span>
					<div>
						<span className='amount'>{props.fulls}</span>
						<span className='amount-c'>{`.${props.cents}`}</span>
						<span className='currency'>  PLN</span>
					</div>
				</div>
			</div>
		</div>
	)
}

export default BankAccountQuickview