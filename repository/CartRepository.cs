using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Tahaluf.SoundCloud.Core.Common;
using Tahaluf.SoundCloud.Core.Data;
using Tahaluf.SoundCloud.Core.Repository;

namespace Tahaluf.SoundCloud.Infra.Repository
{
    public class CartRepository : ICartRepository
    {

            private readonly IDbContext dbContext;
            public CartRepository(IDbContext _dbContext)
            {
                dbContext = _dbContext;
            }


            //public List<Cart> GetUserCart(int id)
            //{

            //    var result = dbContext.Connection.Query<Cart>("Cart_Package.GetUserCart", commandType: CommandType.StoredProcedure);
            //    return result.ToList();
            //}

        public List<Cart> GetUserCart(int id)
        {
            var p = new DynamicParameters();
            p.Add("@CUserid",id, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Cart>("Cart_Package.GetUserCart", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }


        public bool CreateCart(Cart cart)
            {
                var p = new DynamicParameters(); 
                p.Add("@CUserID", cart.UserID, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add("@CSoundID", cart.SoundID, dbType: DbType.Int32, direction: ParameterDirection.Input);
                var result = dbContext.Connection.ExecuteAsync("Cart_Package.CreateCart", p, commandType: CommandType.StoredProcedure);
                return true;
            }



        public bool UpdateCart(Cart cart)
            {

                var p = new DynamicParameters(); // 1-Dapper 2- provide add method 3-enabling you to pass parameter to DBase (Stored Proc)
                p.Add("@CCartId", cart.CartID, dbType: DbType.Int32, direction: ParameterDirection.Input);

            p.Add("@CUserID", cart.UserID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@CSoundID", cart.SoundID, dbType: DbType.Int32, direction: ParameterDirection.Input);
                var result = dbContext.Connection.ExecuteAsync("Cart_Package.UpdateCart", p, commandType: CommandType.StoredProcedure);
                return true;
            }


        public bool DeleteCart(int id)
            {
                var p = new DynamicParameters(); // 1-Dapper 2- provide add method 3-enabling you to pass parameter to DBase (Stored Proc)
                p.Add("@CCartId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
                var result = dbContext.Connection.ExecuteAsync("Cart_Package.DeleteCart", p, commandType: CommandType.StoredProcedure);
                return true;
            }

        }
    }
