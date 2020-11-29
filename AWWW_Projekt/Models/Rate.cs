using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AWWW_Projekt.Models
{
    /// <summary>
    /// Represents single post rating
    /// </summary>
    public class Rate
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(PostId))]
        public int PostId { get; set; }
        public Post Post { get; set; }

        private int _value;
        /// <summary>
        /// Rating value between 1 and 5
        /// </summary>
        public int Value
        {
            get { return _value; }
            set
            {
                if (value < 1)
                {
                    _value = 1;
                }
                else if (value > 5)
                {
                    _value = 5;
                }
                else
                {
                    _value = value;
                }
            }
        }
    }
}
